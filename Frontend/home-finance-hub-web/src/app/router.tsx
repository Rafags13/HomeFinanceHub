import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Layout from "../shared/components/Layout";
import { personRoutes } from "../features/person/routes/person.routes";
import { categoryRoutes } from "../features/category/routes/category.routes";
import { transactionRoutes } from "../features/transaction/routes/transaction.routes";

const router = createBrowserRouter([
  {
    path: "/",
    Component: Layout,
    children: [...personRoutes, ...categoryRoutes, ...transactionRoutes],
  },
]);

export default function Router() {
  return <RouterProvider router={router} />;
}
