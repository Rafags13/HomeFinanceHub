import { formatCurrency } from "../utils/number-helper";

interface MoneyTagProps {
  label: string;
  value: number;
}

export default function MoneyTag({ label, value }: MoneyTagProps) {
  return (
    <p className="font-medium">
      {label}:{" "}
      <span
        className={`font-bold ${
          value > 0
            ? "text-green-500"
            : value === 0
              ? "text-blue-500"
              : "text-red-500"
        }`}
      >
        {formatCurrency(value)}
      </span>
    </p>
  );
}
