import type { EExpenseCategoryType } from "../../../../shared/types/enums/expense-category-type.enum";
import type { KeyValuePair } from "../../../../shared/types/interfaces/key-value-pair";
import type { Pagination } from "../../../../shared/types/interfaces/pagination";
import type { PersonItemDTO } from "./person-item.dto";

export interface PersonPagination extends Pagination<PersonItemDTO> {
  totalExpensesByType: KeyValuePair<EExpenseCategoryType, number>[];
  totalBalance: number;
}
