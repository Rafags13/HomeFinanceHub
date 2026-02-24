import { type ReactNode } from "react";

interface CardActionsProps {
  children: ReactNode;
}

export default function CardActions({ children }: CardActionsProps) {
  return (
    <div className="flex flex-col gap-2 items-center justify-center">
      {children}
    </div>
  );
}
