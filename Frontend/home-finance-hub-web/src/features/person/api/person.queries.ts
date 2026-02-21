import { useQuery } from "@tanstack/react-query";
import { personService } from "./person.service";

export const usePerson = (page: number) =>
  useQuery({
    queryKey: ["person", page],
    queryFn: () => personService.getAll(page),
  });
