import { useMemo } from "react";

interface PaginationProps {
  currentPage: number;
  totalItems: number;
  onPageChange: (page: number) => void;
  siblingCount?: number;
}

export function Pagination({
  currentPage,
  totalItems,
  onPageChange,
  siblingCount = 1,
}: PaginationProps) {
  const paginationRange = useMemo(() => {
    const totalPageNumbers = siblingCount * 2 + 5;

    const currentTotalPageNumbers = totalItems / (10 + 1) + 1;

    if (currentTotalPageNumbers <= totalPageNumbers) {
      return Array.from({ length: currentTotalPageNumbers }, (_, i) => i + 1);
    }

    const leftSiblingIndex = Math.max(currentPage - siblingCount, 1);
    const rightSiblingIndex = Math.min(
      currentPage + siblingCount,
      currentTotalPageNumbers,
    );

    const showLeftDots = leftSiblingIndex > 2;
    const showRightDots = rightSiblingIndex < currentTotalPageNumbers - 1;

    const range: (number | string)[] = [];

    range.push(1);

    if (showLeftDots) {
      range.push("...");
    }

    for (let i = leftSiblingIndex; i <= rightSiblingIndex; i++) {
      console.log(i);
      if (i !== 1 && i !== currentTotalPageNumbers) {
        range.push(i);
      }
    }

    if (showRightDots) {
      range.push("...");
    }

    if (currentTotalPageNumbers > 1) {
      range.push(currentTotalPageNumbers);
    }

    return range;
  }, [currentPage, totalItems, siblingCount]);

  if (totalItems < 0) return null;

  return (
    <nav
      className="flex items-center justify-center gap-2 mt-6"
      aria-label="pagination"
    >
      <button
        onClick={() => {
          onPageChange(currentPage - 1);
        }}
        disabled={currentPage === 0}
        className="px-3 py-1 rounded border disabled:opacity-50 disabled:cursor-not-allowed"
      >
        Prev
      </button>

      {paginationRange.map((item, index) =>
        item === "..." ? (
          <span key={index} className="px-2 text-gray-500">
            ...
          </span>
        ) : (
          <button
            key={index}
            onClick={() => onPageChange(Number(item) - 1)}
            className={`px-3 py-1 rounded border ${
              item === currentPage + 1
                ? "bg-blue-600 text-white"
                : "hover:bg-gray-100"
            }`}
          >
            {item}
          </button>
        ),
      )}

      <button
        onClick={() => onPageChange(currentPage + 1)}
        disabled={currentPage === Math.floor(totalItems / 10)}
        className="px-3 py-1 rounded border disabled:opacity-50 disabled:cursor-not-allowed"
      >
        Next
      </button>
    </nav>
  );
}
