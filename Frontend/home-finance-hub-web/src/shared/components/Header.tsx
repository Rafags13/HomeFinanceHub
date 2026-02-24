import { Link } from "react-router";

export default function Header() {
  return (
    <nav className="py-8 border-b-2 border-black">
      <ul className="flex flex-row gap-4 justify-center">
        <li>
          <Link to="/">Person</Link>
        </li>
        <li>
          <Link to="/transaction">Transactions</Link>
        </li>
        <li>
          <Link to="/category">Categories</Link>
        </li>
      </ul>
    </nav>
  );
}
