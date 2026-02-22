import { useMutation, useQuery } from "@tanstack/react-query";
import { categoryService } from "./category.service";

export const useCategoryPaginated = (page: number) =>
  useQuery({
    queryKey: ["paginatedPerson", page],
    queryFn: () => categoryService.getAll(page),
  });

export const useCreateCategory = () =>
  useMutation({
    mutationFn: categoryService.create,
  });
