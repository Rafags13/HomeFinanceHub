import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  createCategorySchema,
  type CreateCategorySchemaValues,
} from "../schema/create-category.schema";

export function useCreateCategoryForm(
  defaultValues?: CreateCategorySchemaValues,
) {
  return useForm({
    resolver: zodResolver(createCategorySchema),
    defaultValues,
  });
}
