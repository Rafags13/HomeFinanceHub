import type { RouteObject } from "react-router";
import CategoryListPage from "../pages/CategoryListPage";
import CategoryCreatePage from "../pages/CategoryCreatePage";

export const categoryRoutes: RouteObject[] = [
  {
    path: "category",
    Component: CategoryListPage,
  },
  {
    path: "/category/create",
    Component: CategoryCreatePage,
  },
];
