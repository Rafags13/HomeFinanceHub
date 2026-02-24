import type { RouteObject } from "react-router";
import TransactionList from "../pages/TransactionListPage";
import TransactionCreate from "../pages/TransactionCreatePage";

export const transactionRoutes: RouteObject[] = [
  {
    path: "/transaction",
    Component: TransactionList,
  },
  {
    path: "/transaction/create",
    Component: TransactionCreate,
  },
];
