import { getMovieById } from "@/services/movie-service";
import Image from 'next/image';
import styles from '@/app/ui/movie-details.module.css';

export default async function page({ params }: { params: { id: string } }) {
  const movie = await getMovieById(params.id);

  return (
    movie && (<div className={styles.detailsWrapper}>
      <div className={styles.detailsLeft}>
        <div className={styles.imageContainer}>
          <Image
            src={movie.imageUrl}
            alt={movie.name}
            width={300}
            height={512}
          />
        </div>
        <div className={styles.detailsFooter}>
          <p>Year: 2000</p>
          <p>{movie.classification}</p>
        </div>
      </div>
      <div className={`${styles.attributeGroup}`}>
        <div className={styles.header}>
          <h1 className={styles.movieName}>{movie.name}</h1>
          <ul className={`${styles.classification} text-base`}>
            <li><p className="text-slate-600 font-semibold">Duration: </p><p className="text-white">{movie.duration} min</p></li>
            <li><p className="text-slate-600 font-semibold">Rating: </p>{movie.rating}</li>
          </ul>
        </div>
        <p className="text-md">{movie.synopsis}</p>
      </div>
    </div>)
  );
}