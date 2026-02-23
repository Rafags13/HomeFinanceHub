import { useNavigate } from "react-router-dom";
import { useTransactionCreate } from "../api/transaction.queries";
import { useCreateTransactionForm } from "../hooks/useCreateTransactionForm";
import type { CreateTransactionSchemaValues } from "../schemas/create-transaction.schema";
import { expenseCategoryTypeWithoutBothTitle } from "../../../shared/types/enums/expense-category-type.enum";
import { useSearchPerson } from "../../person/api/person.queries";
import { Controller } from "react-hook-form";
import type { KeyValuePair } from "../../../shared/types/interfaces/key-value-pair";
import { Autocomplete } from "../../../shared/components/Autocomplete";
import { useSearchCategory } from "../../category/api/category.queries";

export default function TransactionCreatePage() {
  const {
    handleSubmit,
    register,
    formState,
    watch,
    control,
    setValue,
    resetField,
  } = useCreateTransactionForm();

  const { mutateAsync } = useTransactionCreate();

  const personSearch = watch("personSearch");
  const { data: personData = [], isLoading: isPersonLoading } =
    useSearchPerson(personSearch);

  const categorySearch = watch("categorySearch");
  const { data: categoryData = [], isLoading: isCategoryLoading } =
    useSearchCategory(categorySearch);

  const navigator = useNavigate();

  const onSubmit = async (data: CreateTransactionSchemaValues) => {
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
          <label className="tw-label-container" htmlFor="value">
            <span className="tw-label-text">Value</span>
            <input
              id="value"
              type="number"
              {...register("value", { valueAsNumber: true })}
              className={`tw-input ${formState.errors.value ? "border-red-600" : ""}`}
            />
          </label>
          {formState.errors.value ? (
            <p className="tw-error-message">{formState.errors.value.message}</p>
          ) : null}
        </div>

        <div>
          <label className="tw-label-container" htmlFor="age">
            <span className="tw-label-text">Type</span>

            <select
              id="type"
              {...register("type")}
              className={`tw-input ${formState.errors.type ? "border-red-600" : ""}`}
            >
              <option value={undefined}>Selecione</option>
              {Object.entries(expenseCategoryTypeWithoutBothTitle).map(
                ([key, value]) => (
                  <option key={key} value={key}>
                    {value}
                  </option>
                ),
              )}
            </select>
          </label>
          {formState.errors.type ? (
            <p className="tw-error-message">{formState.errors.type.message}</p>
          ) : null}
        </div>

        <Controller
          name="personSearch"
          control={control}
          render={({ field }) => (
            <label>
              <span className="tw-label-text">Person</span>

              <Autocomplete<KeyValuePair<number, string>>
                value={
                  personData.find((p) => p.key === watch("personId")) ?? null
                }
                onChange={(person) => {
                  if (!person) {
                    resetField("personId");
                    resetField("personSearch");
                    return;
                  }

                  setValue("personId", person.key);
                  field.onChange(person.value);
                }}
                inputClass={`tw-input ${formState.errors.type ? "border-red-600" : ""}`}
                options={personData}
                isLoading={isPersonLoading}
                onSearch={field.onChange}
                getOptionLabel={(p) => p.value}
                getOptionValue={(p) => p.key}
                placeholder="Search Person..."
              />
            </label>
          )}
        />

        <Controller
          name="categorySearch"
          control={control}
          render={({ field }) => (
            <label>
              <span className="tw-label-text">Category</span>

              <Autocomplete<KeyValuePair<number, string>>
                value={
                  categoryData.find((p) => p.key === watch("categoryId")) ??
                  null
                }
                onChange={(category) => {
                  if (!category) {
                    resetField("categoryId");
                    resetField("categorySearch");
                    return;
                  }
                  setValue("categoryId", category.key);
                  field.onChange(category.value);
                }}
                inputClass={`tw-input ${formState.errors.type ? "border-red-600" : ""}`}
                options={categoryData}
                isLoading={isCategoryLoading}
                onSearch={field.onChange}
                getOptionLabel={(p) => p.value}
                getOptionValue={(p) => p.key}
                placeholder="Search category..."
              />
            </label>
          )}
        />

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
