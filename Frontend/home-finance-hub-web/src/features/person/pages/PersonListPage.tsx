import PersonCard from "../components/PersonCard";
import { EPersonCardAction } from "../types/enums/person-card-action.enum";
import { useState } from "react";
import { Modal } from "../../../shared/components/Modal";
import { Pagination } from "../../../shared/components/Pagination";
import { useNavigate } from "react-router-dom";
import { usePaginatedPerson } from "../api/person.queries";

export default function PersonList() {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [currentPage, setCurrentPage] = useState(0);

  const navigate = useNavigate();

  const { data, isLoading } = usePaginatedPerson(currentPage);

  function onCardAction(action: EPersonCardAction, id: number) {
    if (action === EPersonCardAction.Remove) {
      setIsModalOpen(true);
    }

    if (action === EPersonCardAction.Edit) {
      navigate(`person/edit/${id}`);
    }
  }

  return (
    <>
      <section className="flex-1">
        <article className="flex flex-row justify-between">
          <h1 className="text-3xl font-bold">
            Persons ({isLoading ? "-" : data?.totalItems})
          </h1>

          <button
            className="cursor-pointer p-2 border rounded-md mt-4 text-black"
            onClick={() => {
              navigate("person/create");
            }}
          >
            Create +
          </button>
        </article>

        <article className="flex flex-col gap-2 mt-6">
          {isLoading ? (
            <></>
          ) : (
            data?.items.map((person) => (
              <PersonCard
                key={person.id}
                {...person}
                onCardAction={onCardAction}
              />
            ))
          )}
        </article>
      </section>

      <section className="mt-6">
        {isLoading ? (
          <></>
        ) : (
          <Pagination
            currentPage={currentPage}
            totalItems={data?.totalItems ?? 0}
            onPageChange={(page) => {
              setCurrentPage(page);
            }}
          />
        )}
      </section>

      <Modal
        isOpen={isModalOpen}
        onClose={() => {
          setIsModalOpen(false);
        }}
      >
        <span>teste</span>
      </Modal>
    </>
  );
}
