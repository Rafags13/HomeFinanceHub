import { api } from "../../../shared/lib/axios";
import type { KeyValuePair } from "../../../shared/types/interfaces/key-value-pair";
import type { CreatePersonDTO } from "../types/interfaces/create-person.dto";
import type { PersonPagination } from "../types/interfaces/person-pagination";
import type { PersonDTO } from "../types/interfaces/person.dto";
import type { UpdatePersonDTO } from "../types/interfaces/update-person.dto";

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

  getById: async (id: number) => {
    const { data } = await api.get<PersonDTO>(`/person/${id}`);

    return data;
  },

  update: async (body: UpdatePersonDTO) => {
    const { data } = await api.patch<boolean>("/person", body);

    return data;
  },

  delete: async (id: number) => {
    const { data } = await api.delete(`/person/${id}`);

    return data;
  },

  search: async (description: string | null) => {
    const params = description !== null ? { name: description } : null;

    const { data } = await api.get<KeyValuePair<number, string>[]>(
      "/person/search",
      { params },
    );

    return data;
  },
};
