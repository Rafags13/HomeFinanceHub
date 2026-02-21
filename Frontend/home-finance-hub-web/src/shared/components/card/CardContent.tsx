import { type ReactNode } from "react";

interface CardContent {
  children: ReactNode;
}

export default function CardContent({ children }: CardContent) {
  return <div className="flex flex-col gap-2">{children}</div>;
}
