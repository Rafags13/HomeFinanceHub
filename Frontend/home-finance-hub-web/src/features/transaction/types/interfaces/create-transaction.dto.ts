import type { EExpenseCategoryType } from "../../../../shared/types/enums/expense-category-type.enum";

export interface CreateTransactionDTO {
  description?: string;
  value: number;
  type: EExpenseCategoryType;
  categoryId: number;
  personId: number;
}
