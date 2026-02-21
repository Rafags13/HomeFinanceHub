import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Layout from "../shared/components/Layout";
import { personRoutes } from "../features/person/routes";

const router = createBrowserRouter([
  {
    path: "/",
    Component: Layout,
    children: [...personRoutes],
  },
]);

export default function Router() {
  return <RouterProvider router={router} />;
}
