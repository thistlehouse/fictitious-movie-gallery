'use client';

import { StarIcon } from '@heroicons/react/20/solid';

export default function RatingStars({ averageRating }: { averageRating: number }) {
  const Icon = StarIcon;

  return (
    <>
      {[...Array(5)].map((_, i) => (
        <Icon key={i} className={i < averageRating ? "text-yellow-500" : "text-white"} />))}
    </>
  );
}
