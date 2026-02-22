import type { EExpenseCategoryType } from "../../../../shared/types/enums/expense-category-type.enum";

export interface CategoryDTO {
  description: string;
  purposeType: EExpenseCategoryType;
}
