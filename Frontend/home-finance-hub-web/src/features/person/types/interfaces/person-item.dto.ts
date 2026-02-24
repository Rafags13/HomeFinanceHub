import type { EExpenseCategoryType } from "../../../../shared/types/enums/expense-category-type.enum";
import type { KeyValuePair } from "../../../../shared/types/interfaces/key-value-pair";

export interface PersonItemDTO {
  id: number;
  name: string;
  age: number;
  totalExpensesByType: KeyValuePair<EExpenseCategoryType, number>[];
  balance: number;
}
