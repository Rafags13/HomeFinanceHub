import type { ReactNode } from "react";

interface CardSecondaryInformationsProps {
  children: ReactNode;
  className?: string | undefined;
}

export default function CardSecondaryInformations({
  children,
  className,
}: CardSecondaryInformationsProps) {
  return <div className={`flex flex-row gap-2 ${className}`}>{children}</div>;
}
