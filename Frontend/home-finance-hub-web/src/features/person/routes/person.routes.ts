import type { RouteObject } from "react-router";
import PersonList from "../pages/PersonListPage";
import PersonCreate from "../pages/PersonCreatePage";
import PersonUpdate from "../pages/PersonUpdatePage";

export const personRoutes: RouteObject[] = [
  {
    index: true,
    Component: PersonList,
  },
  {
    path: "/person/create",
    Component: PersonCreate,
  },
  {
    path: "/person/edit/:id",
    Component: PersonUpdate,
  },
];
