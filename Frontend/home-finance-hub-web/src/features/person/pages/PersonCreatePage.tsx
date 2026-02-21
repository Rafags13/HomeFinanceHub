import { useNavigate } from "react-router-dom";
import { usePersonForm } from "../hooks/usePersonForm";
import type { PersonSchemaValues } from "../schemas/person.schema";
import { useCreatePerson } from "../api/person.queries";

export default function PersonCreate() {
  const { register, handleSubmit, formState } = usePersonForm();

  const { mutateAsync } = useCreatePerson();

  const navigator = useNavigate();

  const onSubmit = async (data: PersonSchemaValues) => {
    await mutateAsync(data);
    goBack();
  };

  const goBack = () => {
    navigator(-1);
  };

  return (
    <div>
      <h1 className="text-3xl font-bold">Create Person</h1>

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
              {...register("age", { valueAsNumber: true })}
              className={`p-2 border rounded-sm ${formState.errors.age ? "border-red-600" : "border-black"}`}
            />
          </label>
          {formState.errors.age ? (
            <p className="text-red-600 font-medium">
              {formState.errors.age.message}
            </p>
          ) : null}
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
    </div>
  );
}
