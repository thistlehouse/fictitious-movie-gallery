import Image from 'next/image';
import { getMoviesByFilter } from '@/app/services/movie-service';
import { Movie } from '@/app/lib/definitions';
import styles from '@/app/ui/card.module.css';
import { StarIcon } from '@heroicons/react/20/solid';
import Link from 'next/link';
import { useMemo } from 'react';
import { Inter } from 'next/font/google';

const inter = Inter({ subsets: ['latin'] });

export default async function CardsWrapper({ query, }: { query: string, }) {
  const movies: Movie[] = await getMoviesByFilter(query);
  const categories = Array.from(
    new Set(movies.map(movie => movie.category))
  );
  const moviesByCategory = categories.map(category => ({
    category,
    movies: movies.filter(movie => movie.category == category)
  }));

  return (
    <>{movies.length > 0 ? (moviesByCategory.map(category => (
      <section key={category.category} className={styles.categorySection}>
        <h1 className={[styles.category, inter.className].join(' ')}>{category.category}</h1>
        <div className={styles.cardsWrapper}>
          {category.movies.map(movie =>
            <Card key={movie.id} movie={movie} />)}
        </div>
      </section>))) : (<section className={styles.categorySection}>
        <p>We are sorry, no movie was found...</p>
      </section>)}
    </>
  );
}

export function Card({ movie }: { movie: Movie }) {
  const Icon = StarIcon;

  return (
    <Link href={`movies/details/${movie.id}`}>
      <div key={movie.id} className={styles.movieCard}>
        <div className={styles.ratingWrapper}>
          <div className={styles.rating}>
            <Icon className={styles.ratingStar} />
            <p>{movie.rating}</p>
          </div>
        </div>
        <div className={styles.imageWrapper}>
          <Image
            src={movie.imageUrl}
            alt={movie.name}
            width={250}
            height={350}
          />
        </div>
        <div className={styles.details}>
          <h2>{movie.name}</h2>
          <p>{movie.category}</p>
        </div>
      </div>
    </Link>
  );
}