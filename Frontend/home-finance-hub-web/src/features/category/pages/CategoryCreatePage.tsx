import { useNavigate } from "react-router-dom";
import { useCreateCategory } from "../api/category.queries";
import { useCreateCategoryForm } from "../hooks/useCreateCategoryForm";
import type { CreateCategorySchemaValues } from "../schema/create-category.schema";
import { expenseCategoryTypeTitle } from "../../../shared/types/enums/expense-category-type.enum";

export default function CategoryCreatePage() {
  const { handleSubmit, register, formState } = useCreateCategoryForm();
  const { mutateAsync } = useCreateCategory();
  const navigator = useNavigate();

  const onSubmit = async (data: CreateCategorySchemaValues) => {
    await mutateAsync(data);
    goBack();
  };

  const goBack = () => {
    navigator(-1);
  };

  return (
    <>
      <h1 className="tw-title">Create Person</h1>

      <form
        className="flex flex-col my-4 gap-4"
        onSubmit={handleSubmit(onSubmit)}
      >
        <div>
          <label className="tw-label-container" htmlFor="description">
            <span className="tw-label-text">Description</span>
            <input
              id="description"
              className={`tw-input ${formState.errors.description ? "border-red-600" : ""}`}
              {...register("description")}
            />
          </label>
          {formState.errors.description ? (
            <p className="tw-error-message">
              {formState.errors.description.message}
            </p>
          ) : null}
        </div>

        <div>
          <label className="tw-label-container" htmlFor="age">
            <span className="tw-label-text">Purpose Type</span>

            <select
              id="purposeType"
              {...register("purposeType")}
              className={`tw-input ${formState.errors.purposeType ? "border-red-600" : ""}`}
            >
              <option value={undefined}>Selecione</option>
              {Object.entries(expenseCategoryTypeTitle).map(([key, value]) => (
                <option value={key}>{value}</option>
              ))}
            </select>
          </label>
          {formState.errors.purposeType ? (
            <p className="tw-error-message">
              {formState.errors.purposeType.message}
            </p>
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
