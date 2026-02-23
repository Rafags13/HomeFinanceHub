import type { EExpenseCategoryType } from "../../../../shared/types/enums/expense-category-type.enum";

export interface CraeteTransactionDTO {
  description: string | null;
  value: number;
  type: EExpenseCategoryType;
  categoryId: number | null;
  personId: number | null;
}
