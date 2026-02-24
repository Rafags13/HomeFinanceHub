import PersonCard from "../components/PersonCard";
import { EPersonCardAction } from "../types/enums/person-card-action.enum";
import { useState } from "react";
import { Modal } from "../../../shared/components/Modal";
import { Pagination } from "../../../shared/components/Pagination";
import { useNavigate } from "react-router-dom";
import { usePaginatedPerson, useRemovePerson } from "../api/person.queries";

export default function PersonList() {
  const [modalPersonId, setModalPersonId] = useState<number | null>(null);
  const [currentPage, setCurrentPage] = useState(0);

  const navigate = useNavigate();

  const { data, isLoading } = usePaginatedPerson(currentPage);

  const { mutateAsync } = useRemovePerson();

  function onCardAction(action: EPersonCardAction, id: number) {
    if (action === EPersonCardAction.Remove) {
      setModalPersonId(id);
    }

    if (action === EPersonCardAction.Edit) {
      navigate(`person/edit/${id}`);
    }
  }

  return (
    <>
      <section className="flex-1">
        <article className="flex flex-row justify-between">
          <h1 className="tw-title">
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
        isOpen={modalPersonId !== null}
        onClose={() => {
          setModalPersonId(null);
        }}
      >
        <h3 className="tw-subtitle text-center">
          Do you have sure you want to remove it?
        </h3>

        <button
          type="button"
          className="tw-button-outlined"
          onClick={() => {
            setModalPersonId(null);
          }}
        >
          Cancel
        </button>

        <button
          type="button"
          className="tw-button-solid bg-red-500"
          onClick={async () => {
            if (modalPersonId) {
              await mutateAsync(modalPersonId);
              setCurrentPage(0);
              setModalPersonId(null);
            }
          }}
        >
          Remove
        </button>
      </Modal>
    </>
  );
}
