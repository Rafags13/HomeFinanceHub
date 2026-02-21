import z from "zod";

export const createPersonSchema = z.object({
  name: z
    .string()
    .min(3, { error: "Name must be at least 3 characters long" })
    .max(200, { error: "Username cannot exceed 200 characters" }),
  age: z
    .number({ error: "Age must be at least 1 year old" })
    .min(1, { error: "Age must be at least 1 year old" })
    .max(150, { error: "Age cannot exceed 150 years old" }),
});

export type CreatePersonSchemaValues = z.infer<typeof createPersonSchema>;
