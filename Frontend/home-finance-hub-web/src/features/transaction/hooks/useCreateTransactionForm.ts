import { useForm } from "react-hook-form";
import {
  createTransactionSchema,
  type CreateTransactionSchemaValues,
} from "../schemas/create-transaction.schema";
import { zodResolver } from "@hookform/resolvers/zod";

export function useCreateTransactionForm(
  defaultValues?: CreateTransactionSchemaValues,
) {
  return useForm({
    resolver: zodResolver(createTransactionSchema),
    defaultValues,
  });
}
