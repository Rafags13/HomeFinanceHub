import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  personSchema,
  type PersonSchemaValues,
} from "../schemas/person.schema";

export function usePersonForm(defaultValues?: PersonSchemaValues) {
  return useForm({
    resolver: zodResolver(personSchema),
    defaultValues,
  });
}
