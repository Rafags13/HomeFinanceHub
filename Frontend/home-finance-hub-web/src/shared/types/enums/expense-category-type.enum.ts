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

export const expenseCategoryTypeWithoutBothTitle = Object.fromEntries(
  Object.entries(expenseCategoryTypeTitle).filter(
    ([key]) => key !== EExpenseCategoryType.Both,
  ),
);
