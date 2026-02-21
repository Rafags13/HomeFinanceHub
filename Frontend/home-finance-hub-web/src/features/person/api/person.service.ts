import { api } from "../../../shared/lib/axios";
import type { PersonPagination } from "../types/interfaces/person-pagination";

export const personService = {
  getAll: async (page: number) => {
    const { data } = await api.get<PersonPagination>("/person", {
      params: { page },
    });

    return data;
  },
};
