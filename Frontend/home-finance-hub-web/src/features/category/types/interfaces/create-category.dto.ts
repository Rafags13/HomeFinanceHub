import type { EExpenseCategoryType } from "../../../../shared/types/enums/expense-category-type.enum";

export interface CreateCategoryDTO {
  description: string;
  purposeType: EExpenseCategoryType;
}
