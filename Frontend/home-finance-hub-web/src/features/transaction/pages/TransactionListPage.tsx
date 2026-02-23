import { useState } from "react";
import { useTransactionPaginated } from "../api/transaction.queries";
import { useNavigate } from "react-router-dom";
import TransactionCard from "../components/TransactionCard";
import { Pagination } from "../../../shared/components/Pagination";

export default function TransactionListPage() {
  const [page, setPage] = useState(0);
  const { data, isLoading } = useTransactionPaginated(page);

  const navigate = useNavigate();

  return (
    <>
      <section className="flex-1">
        <article className="flex flex-row justify-between">
          <h1 className="tw-title">
            Transactions ({isLoading ? "-" : data?.totalItems})
          </h1>

          <button
            className="cursor-pointer p-2 border rounded-md mt-4 text-black"
            onClick={() => {
              navigate("/category/create");
            }}
          >
            Create +
          </button>
        </article>

        <article className="flex flex-col gap-2 mt-6">
          {isLoading ? (
            <></>
          ) : (
            data?.items.map((category, index) => (
              <TransactionCard key={index} {...category} />
            ))
          )}
        </article>
      </section>

      <section className="mt-6">
        {isLoading ? (
          <></>
        ) : (
          <Pagination
            currentPage={page}
            totalItems={data?.totalItems ?? 0}
            onPageChange={(page) => {
              setPage(page);
            }}
          />
        )}
      </section>
    </>
  );
}
