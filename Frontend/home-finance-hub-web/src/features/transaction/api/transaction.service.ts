import { api } from "../../../shared/lib/axios";
import type { Pagination } from "../../../shared/types/interfaces/pagination";
import type { CreateTransactionDTO } from "../types/interfaces/create-transaction.dto";
import type { TransactionDTO } from "../types/interfaces/transaction.dto";

export const transactionService = {
  getAll: async (page: number) => {
    const { data } = await api.get<Pagination<TransactionDTO>>(
      "/person/transaction",
      {
        params: { page },
      },
    );

    return data;
  },

  create: async (body: CreateTransactionDTO) => {
    const { data } = await api.post<boolean>("/person/transaction", body);

    return data;
  },
};
