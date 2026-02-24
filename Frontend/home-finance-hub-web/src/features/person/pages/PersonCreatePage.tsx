import { useNavigate } from "react-router-dom";
import { useCreatePersonForm } from "../hooks/useCreatePersonForm";
import type { CreatePersonSchemaValues } from "../schemas/create-person.schema";
import { useCreatePerson } from "../api/person.queries";

export default function PersonCreate() {
  const { register, handleSubmit, formState } = useCreatePersonForm();

  const { mutateAsync } = useCreatePerson();

  const navigator = useNavigate();

  const onSubmit = async (data: CreatePersonSchemaValues) => {
    await mutateAsync(data);
    goBack();
  };

  const goBack = () => {
    navigator(-1);
  };

  return (
    <>
      <h1 className="tw-title">Create Person</h1>

      <form className="tw-form" onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label className="tw-label-container" htmlFor="name">
            <span className="tw-label-text">Name</span>
            <input
              id="name"
              className={`tw-input ${formState.errors.name ? "border-red-600" : ""}`}
              {...register("name")}
            />
          </label>
          {formState.errors.name ? (
            <p className="tw-error-message">{formState.errors.name.message}</p>
          ) : null}
        </div>

        <div>
          <label className="tw-label-container" htmlFor="age">
            <span className="tw-label-text">Age</span>
            <input
              id="age"
              type="number"
              {...register("age", { valueAsNumber: true })}
              className={`tw-input ${formState.errors.age ? "border-red-600" : ""}`}
            />
          </label>
          {formState.errors.age ? (
            <p className="tw-error-message">{formState.errors.age.message}</p>
          ) : null}
        </div>

        <div className="flex flex-row gap-2 w-full">
          <button type="submit" className="tw-button-solid">
            Save
          </button>

          <button type="button" className="tw-button-outlined" onClick={goBack}>
            Back
          </button>
        </div>
      </form>
    </>
  );
}
