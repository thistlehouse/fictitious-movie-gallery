export type User = {
  firstName: string,
  lastName: string,
  email: string,
  password: string,
}

export type Movie = {
  id: string;
  name: string;
  year: string;
  classification: string;
  cast: string[];
  duration: number;
  imageUrl: string;
  synopsis: string;
  category: string;
  rating: number;
};