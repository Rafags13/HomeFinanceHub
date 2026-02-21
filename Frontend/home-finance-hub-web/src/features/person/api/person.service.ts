import { api } from "../../../shared/lib/axios";
import type { CreatePersonDTO } from "../types/interfaces/create-person.dto";
import type { PersonPagination } from "../types/interfaces/person-pagination";

export const personService = {
  getAll: async (page: number) => {
    const { data } = await api.get<PersonPagination>("/person", {
      params: { page },
    });

    return data;
  },

  create: async (body: CreatePersonDTO) => {
    const { data } = await api.post<boolean>("/person", body);

    return data;
  },
};
