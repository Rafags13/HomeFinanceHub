import z from "zod";
import { EExpenseCategoryType } from "../../../shared/types/enums/expense-category-type.enum";

export const createCategorySchema = z.object({
  description: z
    .string()
    .min(3, { error: "Name must be at least 3 characters long" })
    .max(400, { error: "Username cannot exceed 200 characters" }),
  purposeType: z.enum(EExpenseCategoryType, {
    error: "Purpose type is required",
  }),
});

export type CreateCategorySchemaValues = z.infer<typeof createCategorySchema>;
