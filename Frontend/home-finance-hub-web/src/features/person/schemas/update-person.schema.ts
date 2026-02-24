import z from "zod";

export const updatePersonSchema = z.object({
  name: z
    .string()
    .min(3, { error: "Name must be at least 3 characters long" })
    .max(200, { error: "Username cannot exceed 200 characters" }),
});

export type UpdatePersonSchemaValues = z.infer<typeof updatePersonSchema>;
