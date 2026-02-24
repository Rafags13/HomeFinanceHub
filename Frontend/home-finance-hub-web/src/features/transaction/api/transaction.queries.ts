import { useMutation, useQuery } from "@tanstack/react-query";
import { transactionService } from "./transaction.service";

export const useTransactionPaginated = (page: number) =>
  useQuery({
    queryKey: ["paginatedTransaction", page],
    queryFn: () => transactionService.getAll(page),
  });

export const useTransactionCreate = () =>
  useMutation({
    mutationFn: transactionService.create,
  });
