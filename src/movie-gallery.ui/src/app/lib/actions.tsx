'use server';

import { z } from "zod";
import { rateMovie, registerUser } from "@/app/services/movie-service";
import { revalidatePath } from "next/cache";
import { redirect } from "next/navigation";
import { User } from "./definitions";

export type State = {
  errors?: {
    firstName?: string[];
    lastName?: string[];
    email?: string[];
    password?: string[];
    confirmPassword?: string[];
  };
  message?: string | null;
};

const RegisterSchema = z
  .object({
    firstName: z.string({
      invalid_type_error: 'Please write first name',
    }),
    lastName: z.string({
      invalid_type_error: 'Please write last name',
    }),
    email: z.string({
      invalid_type_error: 'Please write email',
    }),
    password: z.string(),
    confirmPassword: z.string(),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Passwords don't match.",
    path: ["confirmPassword"]
  })
  .transform((data) => ({
    firstName: data.firstName,
    lastName: data.lastName,
    email: data.email,
    password: data.password,
    confirmPassword: data.confirmPassword,
  }));

export async function register(prevState: State, formData: FormData): Promise<State> {
  const validateFields = RegisterSchema.safeParse({
    firstName: formData.get('firstName'),
    lastName: formData.get('lastName'),
    email: formData.get('email'),
    password: formData.get('password'),
    confirmPassword: formData.get('confirmPassword'),
  });

  if (!validateFields.success) {
    return {
      errors: validateFields.error.flatten().fieldErrors,
    };
  }

  const {
    firstName,
    lastName,
    email,
    password,
  } = validateFields.data;

  const user: User = {
    firstName: firstName,
    lastName: lastName,
    email: email,
    password: password,
  }

  try {
    await registerUser(user);
  } catch (error: any) {
    console.log(error.response.data);
    return {
      message: `${error.response.data.message}`,
    }
  }

  revalidatePath('/register');
  redirect('/');
}

export async function movieRating(
  prevState: number | undefined,
  formData: FormData,
): Promise<number> {
  const rating: number = Number(formData.get('rating'));
  await rateMovie(rating);

  // revalidatePath('/');
  redirect('/');
}