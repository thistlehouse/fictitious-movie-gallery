import { unstable_noStore as noStore } from "next/cache";
import axios from "axios";

const baseUrl = axios.create({ baseURL: "http://localhost:5106/movies" }); // process.env.MOVIE_API + "/movies"

export async function getMovies() {
  noStore();

  try {
    const response = await baseUrl.get("/all");

    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getMovieById(id: string) {
  noStore();

  try {
    const response = await baseUrl.get(`/details/${id}`);

    return response.data;
  } catch (error) {
    console.log(error);
  }
}

export async function getMoviesByFilter(filter: string) {
  noStore();
  try {
    const response = await baseUrl.get(`/search/?filter=${filter.toLowerCase()}`);

    return response.data;
  } catch (error) {
    return [];
  }
}