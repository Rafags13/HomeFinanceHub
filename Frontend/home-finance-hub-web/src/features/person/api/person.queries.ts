import { useMutation, useQuery } from "@tanstack/react-query";
import { personService } from "./person.service";

export const usePaginatedPerson = (page: number) =>
  useQuery({
    queryKey: ["paginatedPerson", page],
    queryFn: () => personService.getAll(page),
  });

export const useCreatePerson = () =>
  useMutation({
    mutationFn: personService.create,
  });

export const usePerson = (id: number) =>
  useQuery({
    queryKey: ["person", id],
    queryFn: () => personService.getById(id),
  });

export const useUpdatePerson = () =>
  useMutation({
    mutationFn: personService.update,
  });

export const useSearchPerson = (description: string | null) =>
  useQuery({
    queryKey: ["searchPerson", description],
    queryFn: () => personService.search(description),
  });
