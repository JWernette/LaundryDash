'use client';
import { useRouter } from 'next/navigation';
import {
  Card,
  CardHeader,
  CardContent,
  CardTitle,
  CardDescription,
} from '@/components/ui/card';
import { cn } from '@/lib/utils';

export function AccountSelection({
  className,
  ...props
}: React.ComponentPropsWithoutRef<'div'>) {
  const router = useRouter();

  const handleSelection = (accountType: 'customer' | 'dasher') => {
    // Navigate to the signup page with the account type as a query parameter.
    router.push(`/signup?accountType=${accountType}`);
  };

  return (
    <div
      className={cn('flex flex-col items-center gap-6', className)}
      {...props}
    >
      <h1 className="text-2xl font-semibold">Sign Up As</h1>
      <div className="flex gap-6">
        <Card
          className="cursor-pointer hover:shadow-lg transition-shadow"
          onClick={() => handleSelection('customer')}
        >
          <CardHeader className="text-center">
            <CardTitle>Customer</CardTitle>
            <CardDescription>
              Sign up to order laundry services.
            </CardDescription>
          </CardHeader>
          <CardContent>{/* Optional: Add an icon or image here */}</CardContent>
        </Card>
        <Card
          className="cursor-pointer hover:shadow-lg transition-shadow"
          onClick={() => handleSelection('dasher')}
        >
          <CardHeader className="text-center">
            <CardTitle>Dasher</CardTitle>
            <CardDescription>
              Sign up to deliver laundry orders.
            </CardDescription>
          </CardHeader>
          <CardContent>{/* Optional: Add an icon or image here */}</CardContent>
        </Card>
      </div>
    </div>
  );
}
