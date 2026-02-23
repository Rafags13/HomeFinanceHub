import z from "zod";
import { EExpenseCategoryType } from "../../../shared/types/enums/expense-category-type.enum";

export const createTransactionSchema = z.object({
  description: z
    .string()
    .max(400, {
      error: "Transaction cannot exceed 400 characters",
    })
    .optional(),
  value: z.number({
    error: "Value is required",
  }),
  type: z.enum(EExpenseCategoryType, {
    error: "Purpose type is required",
  }),
  categoryId: z.number({
    error: "Category is required",
  }),
  personId: z.number({
    error: "Person is required",
  }),
});

export type CreateTransactionSchemaValues = z.infer<
  typeof createTransactionSchema
>;
