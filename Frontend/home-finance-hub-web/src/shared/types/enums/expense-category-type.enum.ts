export enum EExpenseCategoryType {
  Expenditure = "Expenditure",
  Revenue = "Revenue",
  Both = "Both",
}

export const expenseCategoryTypeTitle: Record<EExpenseCategoryType, string> = {
  [EExpenseCategoryType.Expenditure]: "Despesa",
  [EExpenseCategoryType.Revenue]: "Receita",
  [EExpenseCategoryType.Both]: "Ambos",
};
