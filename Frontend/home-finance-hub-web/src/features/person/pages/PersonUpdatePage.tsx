import { useNavigate, useParams } from "react-router";
import { usePerson, useUpdatePerson } from "../api/person.queries";
import { useUpdatePersonForm } from "../hooks/useUpdatePersonForm";
import type { UpdatePersonSchemaValues } from "../schemas/update-person.schema";

export default function PersonUpdate() {
  const { mutateAsync } = useUpdatePerson();

  const { id } = useParams();

  const { data, isLoading } = usePerson(Number(id));

  const { register, handleSubmit, formState } = useUpdatePersonForm(data);

  const navigator = useNavigate();

  const onSubmit = async (data: UpdatePersonSchemaValues) => {
    await mutateAsync({ ...data, id: Number(id) });
    goBack();
  };

  const goBack = () => {
    navigator(-1);
  };

  return (
    <>
      <h1 className="text-3xl font-bold">Update Person</h1>
      {isLoading ? (
        <></>
      ) : (
        <form
          className="flex flex-col my-4 gap-4"
          onSubmit={handleSubmit(onSubmit)}
        >
          <div>
            <label className="flex flex-col gap-1" htmlFor="name">
              <span className="font-medium">Name</span>
              <input
                id="name"
                className={`p-2 border rounded-sm ${formState.errors.name ? "border-red-600" : "border-black"} `}
                {...register("name")}
              />
            </label>
            {formState.errors.name ? (
              <p className="text-red-600 font-medium">
                {formState.errors.name.message}
              </p>
            ) : null}
          </div>

          <div>
            <label className="flex flex-col gap-1" htmlFor="age">
              <span className="font-medium">Age</span>
              <input
                id="age"
                type="number"
                className={"p-2 border rounded-sm border-black"}
                disabled
                value={data?.age}
              />
            </label>
          </div>

          <div className="flex flex-row gap-2 w-full">
            <button
              type="submit"
              className="p-2 border rounded-md cursor-pointer mt-4 bg-black text-white font-bold w-full"
            >
              Save
            </button>

            <button
              type="button"
              className="p-2 border rounded-md cursor-pointer mt-4 text-black w-full"
              onClick={goBack}
            >
              Back
            </button>
          </div>
        </form>
      )}
    </>
  );
}
