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
      <h1 className="tw-title">Update Person</h1>
      {isLoading ? (
        <></>
      ) : (
        <form
          className="flex flex-col my-4 gap-4"
          onSubmit={handleSubmit(onSubmit)}
        >
          <div>
            <label className="tw-label-container" htmlFor="name">
              <span className="tw-label-text">Name</span>
              <input
                id="name"
                className={`p-2 border rounded-sm ${formState.errors.name ? "border-red-600" : "border-black"} `}
                {...register("name")}
              />
            </label>
            {formState.errors.name ? (
              <p className="tw-error-message">
                {formState.errors.name.message}
              </p>
            ) : null}
          </div>

          <div>
            <label className="tw-label-container" htmlFor="age">
              <span className="tw-label-text">Age</span>
              <input
                id="age"
                type="number"
                className={"tw-input"}
                disabled
                value={data?.age}
              />
            </label>
          </div>

          <div className="flex flex-row gap-2 w-full">
            <button type="submit" className="tw-button-solid">
              Save
            </button>

            <button
              type="button"
              className="tw-button-outlined"
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
