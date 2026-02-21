import { useMutation, useQuery } from "@tanstack/react-query";
import { personService } from "./person.service";

export const usePerson = (page: number) =>
  useQuery({
    queryKey: ["person", page],
    queryFn: () => personService.getAll(page),
  });

export const useCreatePerson = () =>
  useMutation({
    mutationFn: personService.create,
  });
