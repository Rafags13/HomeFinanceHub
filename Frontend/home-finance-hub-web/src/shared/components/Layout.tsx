import { Outlet } from "react-router";
import Header from "./Header";

export default function Layout() {
  return (
    <div className="min-h-screen flex flex-col">
      <header>
        <Header />
      </header>

      <main className="flex-1 container mx-auto px-6 py-6">
        <Outlet />
      </main>
    </div>
  );
}
