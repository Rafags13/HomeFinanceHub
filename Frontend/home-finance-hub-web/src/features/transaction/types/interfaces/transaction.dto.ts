import type { EExpenseCategoryType } from "../../../../shared/types/enums/expense-category-type.enum";

export interface TransactionDTO {
  description: string | null;
  value: number;
  type: EExpenseCategoryType;
  categoryDescription: string;
  personName: string;
}
