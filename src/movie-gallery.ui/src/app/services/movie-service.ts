import { unstable_noStore as noStore } from "next/cache";
import axios from "axios";
import { User } from "@/app/lib/definitions";

const baseUrl = axios.create({ baseURL: "http://localhost:5106/" }); // process.env.MOVIE_API + "/movies"

export async function getMovies() {
  noStore();

  try {
    const response = await baseUrl.get("movies/all");

    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getMovieById(id: string) {
  noStore();

  try {
    const response = await baseUrl.get(`movies/details/${id}`);

    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getMoviesByFilter(filter: string) {
  noStore();
  try {
    const response = await baseUrl.get(`movies/search/?filter=${filter.toLowerCase()}`);

    return response.data;
  } catch (error) {
    return [];
  }
}

export async function registerUser(user: User) {
  noStore();

  return await baseUrl.post('auth/register', {
    firstName: user.firstName,
    lastName: user.lastName,
    email: user.email,
    password: user.password,
  })
    .then((response) => response.data);
}