import { zodResolver } from "@hookform/resolvers/zod";
import { updatePersonSchema } from "../schemas/update-person.schema";
import { useForm } from "react-hook-form";
import type { PersonDTO } from "../types/interfaces/person.dto";

export function useUpdatePersonForm(values?: PersonDTO) {
  return useForm({
    resolver: zodResolver(updatePersonSchema),
    values,
  });
}
