import { api } from "../../../shared/lib/axios";
import type { Pagination } from "../../../shared/types/interfaces/pagination";
import type { CategoryDTO } from "../types/interfaces/category.dto";
import type { CreateCategoryDTO } from "../types/interfaces/create-category.dto";

export const categoryService = {
  getAll: async (page: number) => {
    const { data } = await api.get<Pagination<CategoryDTO>>(
      "/person/transaction/category",
      {
        params: page,
      },
    );

    return data;
  },

  create: async (body: CreateCategoryDTO) => {
    const { data } = await api.post<boolean>(
      "/person/transaction/category",
      body,
    );

    return data;
  },
};
