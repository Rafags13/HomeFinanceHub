import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  createPersonSchema,
  type CreatePersonSchemaValues,
} from "../schemas/create-person.schema";

export function useCreatePersonForm(defaultValues?: CreatePersonSchemaValues) {
  return useForm({
    resolver: zodResolver(createPersonSchema),
    defaultValues,
  });
}
